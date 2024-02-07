using ITLATv.Application.Repositories;
using ITLATv.Application.ViewModels.Serie;
using ITLATv.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Application.Services
{
    public class SerieService
    {
        private readonly SerieRepository _repository;
        private readonly GenderRepository _genderRepository;
        public SerieService(SerieRepository repository, GenderRepository genderRepository)
        {
            _repository = repository;
            _genderRepository = genderRepository;
        }
        public async Task Add(SerieSaveViewModel SaveViewModel)
        {
            Serie serie = new();
            serie.Id = SaveViewModel.Id;
            serie.Name = SaveViewModel.Name;
            serie.ImageURL = SaveViewModel.ImageURL;
            serie.VideoURL = SaveViewModel.VideoURL;
            serie.ProducterId = SaveViewModel.ProducterId;
            serie.PrimaryGenderId = SaveViewModel.GenderId;
            serie.SecondaryGenderId = SaveViewModel.SecondaryGenderId;
            

            await _repository.AddAsync(serie);
        }

        public async Task Delete(int id)
        {
            var serie = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(serie);
        }

        public async Task<List<SerieViewModel>> GetAll()
        {
            var series = await _repository.GetAllIncludeAsync(new List<string> { "Producter", "PrimaryGender", "SecondaryGender" });
            return series.Select(s => new SerieViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImageURL = s.ImageURL,
                VideoURL = s.VideoURL,
                ProducterId = s.ProducterId,
                GenderId = s.PrimaryGenderId,
                ProducterName = s.Producter?.Name,
                GenderName = s.PrimaryGender?.Name,
                SecondaryGenderId = s.SecondaryGenderId,
                SecondayGenderName = s.SecondaryGender?.Name,
                
               
                

            }).ToList();
        }

        public async Task<List<SerieViewModel>> GetAllWithFilters(FilterSeriesViewModel vm)
        {
            var series = await _repository.GetAllIncludeAsync(new List<string> {"Producter", "PrimaryGender", "SecondaryGender"});
            var list = series.Select(s=>new SerieViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImageURL = s.ImageURL,
                VideoURL = s.VideoURL,
                ProducterId = s.ProducterId,
                GenderId = s.PrimaryGenderId,
                ProducterName = s.Producter.Name,
                GenderName = s.PrimaryGender?.Name,
                SecondaryGenderId = s.SecondaryGenderId,
                SecondayGenderName = s.SecondaryGender?.Name,
            }).ToList();

            if (vm.GenderId != null)
            {
                list = list.Where(s=> s.GenderId == vm.GenderId.Value || s.SecondaryGenderId == vm.GenderId.Value).ToList();
            }
            else if (vm.ProducterId != null)
            {
                list = list.Where(s => s.ProducterId == vm.ProducterId.Value).ToList();
            }

            return list;


        }

        public async Task<SerieSaveViewModel> GetById(int id)
        {
            var serie = await _repository.GetByIdAsync(id);
            SerieSaveViewModel vm = new();
            vm.Id = serie.Id;
            vm.Name = serie.Name;
            vm.ImageURL = serie.ImageURL;
            vm.VideoURL = serie.VideoURL;
            vm.ProducterId = serie.ProducterId;
            vm.GenderId = serie.PrimaryGenderId;
            vm.SecondaryGenderId = serie.SecondaryGenderId;
             
            return vm;
        }

        public async Task<List<SerieViewModel>> GetByName(string name)
        {
            
            var series = await _repository.GetAllIncludeAsync(new List<string> { "Producter", "PrimaryGender", "SecondaryGender"});
            var list = series.Select( x=> new SerieViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageURL = x.ImageURL,
                VideoURL = x.VideoURL,
                ProducterId = x.ProducterId,
                GenderId = x.PrimaryGenderId,
                GenderName = x.PrimaryGender?.Name,
                ProducterName = x.Producter?.Name,
                SecondaryGenderId = x.SecondaryGenderId,
                SecondayGenderName = x.SecondaryGender?.Name,

            }).ToList();

            if (name != null)
            {
                list = list.Where(s=>s.Name.StartsWith(name) || s.Name.Contains(name)).ToList();
            }

            return list;
        }

        public async Task Update(SerieSaveViewModel SaveViewModel)
        {
            Serie serie = new();
            serie.Id = SaveViewModel.Id;
            serie.Name = SaveViewModel.Name;
            serie.ImageURL = SaveViewModel.ImageURL;
            serie.VideoURL = SaveViewModel.VideoURL;
            serie.ProducterId= SaveViewModel.ProducterId;
            serie.PrimaryGenderId = SaveViewModel.GenderId;
            serie.VideoURL= SaveViewModel.VideoURL;
            serie.SecondaryGenderId = SaveViewModel.SecondaryGenderId;
            

            await _repository.UpdateAsync(serie);
        }
    }
}
