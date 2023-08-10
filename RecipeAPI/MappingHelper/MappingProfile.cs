using AutoMapper;
using RecipeAPI.Dto;
using RecipeAPI.Models;

namespace RecipeAPI.MappingHelper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            // CreateMap<Source, Destination>();

            CreateMap<Basket, BasketDTO>(); 
            CreateMap<BasketDTO, Basket>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Cuisine, CuisineDTO>();
            CreateMap<CuisineDTO, Cuisine>();

            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<IngredientDTO, Ingredient>();

            CreateMap<Recipe, RecipeDTO>();
            CreateMap<RecipeDTO, Recipe>();

            CreateMap<RecipeIngredient, RecipeIngredientDTO>();
            CreateMap<RecipeIngredientDTO, RecipeIngredient>();

            CreateMap<WeekSchedule, WeekScheduleDTO>();
            CreateMap<WeekScheduleDTO, WeekSchedule>();



        }
    }
}
