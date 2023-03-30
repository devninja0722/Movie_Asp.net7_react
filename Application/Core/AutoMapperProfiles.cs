using Application.MovieRoom.DTO;
using Application.Movies.DTO;
using Application.Profile.DTO;
using Model;

namespace Application.Core;

public class AutoMapperProfiles : AutoMapper.Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Movie, MovieDTO>();
        
        CreateMap<Room, RoomDTO>()
            .ForMember(m => m.Movie, o => o.MapFrom(rm => rm.Movie));

        CreateMap<MovieDTO, Movie>();
        
        CreateMap<UpdateProfileDTO, UserApp>();
        
        CreateMap<UserApp, ProfileDTO>()
            .ForMember(o => o.FavoriteMovies, o => o.MapFrom(u => u.FavoriteMovies.Select(fm => fm.Movie)))
            .ForMember(o => o.Photo, o => o.MapFrom(u => u.Photo.FirstOrDefault(x => x.IsMain).Url));

        CreateMap<UserRoom, AttendeesDTO>()
            .ForMember(u => u.Username, o => o.MapFrom(a => a.User.UserName))
            .ForMember(u => u.DisplayName, o => o.MapFrom(a => a.User.DisplayName))
            .ForMember(o => o.Photo, o => o.MapFrom(u => u.User.Photo.FirstOrDefault(x => x.IsMain).Url));;
        
    }
}
