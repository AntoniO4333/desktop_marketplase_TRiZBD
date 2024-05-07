using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using web_marketplase_TRiZBD.Models;
using Microsoft.EntityFrameworkCore;
using static web_marketplase_TRiZBD.Models.Classes;
using System.Windows;

namespace web_marketplase_TRiZBD.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private readonly MarketplaceContext _context;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public ICommand AddProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand EditProductCommand { get; }

        public ProductsViewModel()
        {
            _context = new MarketplaceContext();
            AddProductCommand = new RelayCommand(ExecuteAddProduct);
            DeleteProductCommand = new RelayCommand(ExecuteDeleteProduct, CanExecuteModifyProduct);
            EditProductCommand = new RelayCommand(ExecuteEditProduct, CanExecuteModifyProduct);

            LoadInitialData();
        }

        private void LoadInitialData()
        {
            var products = _context.Products.ToList();
            Application.Current.Dispatcher.Invoke(() => {
                Products = new ObservableCollection<Product>(products);
                OnPropertyChanged(nameof(Products)); // Убедитесь, что UI обновляется
            });
        }





        private void ExecuteAddProduct(object parameter)
        {
            var newProduct = new Product { Name = "New Product", Price = 0, Quantity = 0 };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            Products.Add(newProduct);
            SelectedProduct = newProduct;
        }

        private void ExecuteDeleteProduct(object parameter)
        {
            if (SelectedProduct != null && Products.Contains(SelectedProduct))
            {
                _context.Products.Remove(SelectedProduct);
                _context.SaveChanges();
                Products.Remove(SelectedProduct);
            }
        }

        private void ExecuteEditProduct(object parameter)
        {
            if (SelectedProduct != null)
            {
                _context.Entry(SelectedProduct).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        private bool CanExecuteModifyProduct(object parameter)
        {
            return SelectedProduct != null;
        }
    }
}
