using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Responses;
using Domain.Entities;
using Mapster;

namespace Aplication.Mappings
{
    public class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<List<Movie>, GetMoviesRespose>.NewConfig()
                .Map(dest => dest.MovieDtos, src => src);

            TypeAdapterConfig<Movie, GetMovieByIdResponse>.NewConfig()
                .Map(dest => dest.MovieDto, src => src);
        }
    }
}
