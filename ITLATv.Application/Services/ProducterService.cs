using ITLATv.Application.Repositories;
using ITLATv.Application.ViewModels.Gender;
using ITLATv.Application.ViewModels.Producter;
using ITLATv.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Application.Services
{
    public class ProducterService
    {
        private readonly ProducterRepository _repository;
        public ProducterService(ProducterRepository repository)
        {
            _repository = repository;
        }
        public async Task Add(ProducterSaveViewModel SaveViewModel)
        {
            Producter producter = new();
            producter.Id = SaveViewModel.Id;
            producter.Name = SaveViewModel.Name;

            await _repository.AddAsync(producter);
        }

        public async Task Delete(int id)
        {
            var gender = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(gender);
        }

        public async Task<List<ProducterViewModel>> GetAll()
        {
            var producter = await _repository.GetAllAsync();
            return producter.Select(p => new ProducterViewModel
            {
                Id = p.Id,
                Name = p.Name,

            }).ToList();
        }

        public async Task<ProducterSaveViewModel> GetById(int id)
        {
            var producter = await _repository.GetByIdAsync(id);
            ProducterSaveViewModel vm = new();
            vm.Id = producter.Id;
            vm.Name = producter.Name;
            return vm;
        }

        public async Task Update(ProducterSaveViewModel SaveViewModel)
        {
            Producter producter = new();
            producter.Id =SaveViewModel.Id;
            producter.Name = SaveViewModel.Name;

            await _repository.UpdateAsync(producter);

        }
    }
}
