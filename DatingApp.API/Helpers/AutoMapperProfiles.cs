using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(destinationMember => destinationMember.PhotoUrl, destinationMember =>
                {
                    destinationMember.MapFrom(user => user.Photos.FirstOrDefault(photo => photo.IsMain).Url);
                })
                .ForMember(destinationMember =>destinationMember.Age, destinationMember=>{
                    destinationMember.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserForDetailedDto>()
                .ForMember(destinationMember => destinationMember.PhotoUrl, destinationMember =>
                {
                    destinationMember.MapFrom(user => user.Photos.FirstOrDefault(photo => photo.IsMain).Url);
                })
                .ForMember(destinationMember => destinationMember.Age, destinationMember =>
                {
                    destinationMember.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}
