
using ITLATv.Application.Repositories;
using ITLATv.Application.ViewModels.Gender;
using ITLATv.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Application.Services
{
    public class GenderService
    {
        private readonly GenderRepository _repository;
        public GenderService(GenderRepository repository)
        {
            _repository = repository;
        }
        public async Task Add(GenderSaveViewModel SaveViewModel)
        {
            Gender gender = new();
            gender.Id = SaveViewModel.Id;
            gender.Name = SaveViewModel.Name;

            await _repository.AddAsync(gender);
        }

        public async Task Delete(int id)
        {
            var gender = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(gender);
        }

        public async Task<List<GenderViewModel>> GetAll()
        {
            var genders = await _repository.GetAllAsync();
            return genders.Select(gender => new GenderViewModel
            {
                Id = gender.Id,
                Name = gender.Name,

            }).ToList();
        }

        public async Task<GenderSaveViewModel> GetById(int id)
        {
            var gender = await _repository.GetByIdAsync(id);
            GenderSaveViewModel vm = new();
            vm.Id = gender.Id;
            vm.Name = gender.Name;
            return vm;
        }

        public async Task Update(GenderSaveViewModel SaveViewModel)
        {
            Gender gender = new();
            gender.Id =SaveViewModel.Id;
            gender.Name = SaveViewModel.Name;

            await _repository.UpdateAsync(gender);

        }
    }
}
