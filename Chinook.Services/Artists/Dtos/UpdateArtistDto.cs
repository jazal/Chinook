using AutoMapper;
using Chinook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Services.Artists.Dtos
{
    [AutoMap(typeof(Artist), ReverseMap = true)]
    public class UpdateArtistDto
    {
        public long ArtistId { get; set; }
        public string? Name { get; set; }
    }
}
