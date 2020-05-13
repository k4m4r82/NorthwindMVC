using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NorthwindApp.View;
using NorthwindApp.Model.Entity;
using NorthwindApp.Model.Repository;
using NorthwindApp.Model.Context;

namespace NorthwindApp.Controller
{
    public class ProductController
    {
        private IBaseView<Product> _view;
        private IProductRepository _repository;

        public ProductController(IBaseView<Product> view)
        {
            _view = view;
        }

        public void LoadData()
        {
            using (var context = new DbContext())
            {
                _repository = new ProductRepository(context);

                var list = _repository.GetAll();
                _view.OnLoadData(list);
            }
        }

        public void Save(Product obj)
        {
            var result = 0;

            using (var context = new DbContext())
            {
                _repository = new ProductRepository(context);

                result = _repository.Save(obj);

                if (result > 0)
                    _view.OnSaved(obj);
                else
                    _view.OnFailed("Data produk gagal disimpan");                
            }
        }

        public void Update(Product obj)
        {
            var result = 0;

            using (var context = new DbContext())
            {
                _repository = new ProductRepository(context);

                result = _repository.Update(obj);

                if (result > 0)
                    _view.OnUpdated(obj);
                else
                    _view.OnFailed("Data produk gagal diupdate");
            }
        }

        public void Delete(Product obj)
        {
            var result = 0;

            using (var context = new DbContext())
            {
                _repository = new ProductRepository(context);

                result = _repository.Delete(obj);

                if (result > 0)
                    _view.OnDeleted(obj);
                else
                    _view.OnFailed("Data produk gagal dihapus");
            }
        }        
    }
}
