using EFCoreRelationsHw.Data;
using EFCoreRelationsHw.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationsHw.Services
{
    public class MovieService
    {
        private readonly MoviesContext _context;

        public MovieService(MoviesContext context)
        {
            _context = context;
        }

        public void AddMovie(string title, int year, string description, int userId)
        {
            var movie = new Movie
            {
                Title = title,
                Year = year,
                Description = description,
                UserId = userId
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.Include(m => m.User).ToList();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public void UpdateMovie(int id, string newTitle)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                movie.Title = newTitle;
                _context.SaveChanges();
            }
        }
    }
}
