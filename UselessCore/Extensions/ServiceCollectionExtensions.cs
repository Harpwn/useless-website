using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Services.Characters;
using UselessCore.Services.Entries;
using UselessCore.Services.Games;
using UselessCore.Services.Images;
using UselessCore.Services.Tags;
using UselessCore.Services.Users;

namespace UselessCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ISectionBuilderFactory, SectionBuilderFactory>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImageService>();
        }
    }
}
