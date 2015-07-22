using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Shorty.Data; 

namespace Shorty.Core
{
    public interface IShortener
    {
        List<UserDto> GetAll();
        UserDto ShortenUrl(UserDto userDto);
        UserDto ExpandUrl(string shortUrl); 

    }

    public class ShortService: IShortener  
    {
        private readonly IConverter _shorteningAlgorithm;
        private readonly IRepository _repository;

        public ShortService(IConverter shorteningAlgorithm, IRepository repository)
        {
            _shorteningAlgorithm = shorteningAlgorithm;
            _repository = repository;
            Mapper.CreateMap<UserUrl, UserDto>().ReverseMap();
        }

        public List<UserDto> GetAll()
        {

            var dbUrls = _repository.GetAll().ToList();

            var urls = Mapper.Map<List<UserDto>>(dbUrls);

            return urls; 
        }



        /// <summary>
        /// Shortens Url 
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public UserDto ShortenUrl(UserDto userDto)
        {
           // Mapper.CreateMap<UserUrl, UserDto>().ReverseMap();
            // map the url to the datalayer. 
            var url = Mapper.Map<UserUrl>(userDto); 
            // save the incoming url into db 
            var result =  _repository.SaveUrl(url); 
            // shorten it 
            userDto.Url = _shorteningAlgorithm.Encode(result.Id); 
            // save back 
            url.Id = result.Id;
            _repository.SaveUrl(url);

            return userDto; 
        }
       
        /// <summary>
        /// Expands shortened url back to the original form. 
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns></returns>
        public UserDto ExpandUrl(string shortUrl)
        {
            //var stringId = StripDomainPart(shortUrl); 
                
            // decode 
            var id =  _shorteningAlgorithm.Decode(shortUrl); 
            // fetch by id 
            var dbUrl = _repository.GetById(id);
            // map it 
            Mapper.CreateMap<UserUrl, UserDto>();
          
            var userUrl = Mapper.Map<UserDto>(dbUrl); 

            //TODO: add access time stamps and increment the count. 

            // return 
            return userUrl; 
        }

        /// <summary>
        /// Removes the domain part from the URL
        /// </summary>
        /// <param name="shortUrl"></param>
        /// <returns></returns>
        private string StripDomainPart(string shortUrl)
        {
            shortUrl = shortUrl.Replace("http://", string.Empty);
            var urlArray = shortUrl.Split('/');

            if (urlArray.Length > 0)
            {
                // second part is the id we need. 
                return urlArray[1];
            }

            return string.Empty;
        }

    }
}