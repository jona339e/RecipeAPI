using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Dto;
using RecipeAPI.Interfaces;
using RecipeAPI.Models;

namespace RecipeAPI.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SearchRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SearchResultDTO SearchRecipes(SearchDTO searchCriteria)
        {
            IQueryable<Recipe> query = _context.Recipes
                .Include(recipe => recipe.RecipeIngredients)
                    .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .Include(recipe => recipe.Categories)
                .Include(recipe => recipe.Cuisines);

            if (!string.IsNullOrWhiteSpace(searchCriteria.SearchText))
            {
                query = query.Where(recipe =>
                    recipe.Name.Contains(searchCriteria.SearchText) ||
                    recipe.RecipeIngredients.Any(ri => ri.Ingredient.Name.Contains(searchCriteria.SearchText)) ||
                    recipe.Categories.Any(category => category.Name.Contains(searchCriteria.SearchText)) ||
                    recipe.Cuisines.Any(cuisine => cuisine.Name.Contains(searchCriteria.SearchText)));
            }

            if (searchCriteria.Categories != null && searchCriteria.Categories.Count > 0)
            {
                query = query.Where(recipe => recipe.Categories.Any(category => searchCriteria.Categories.Contains(category.Name)));
            }

            if (searchCriteria.Cuisines != null && searchCriteria.Cuisines.Count > 0)
            {
                query = query.Where(recipe => recipe.Cuisines.Any(cuisine => searchCriteria.Cuisines.Contains(cuisine.Name)));
            }

            List<Recipe> recipes = query.ToList();

            SearchResultDTO searchResult = new SearchResultDTO
            {
                MatchingRecipes = recipes
            };

            return searchResult;
        }
    }

}

