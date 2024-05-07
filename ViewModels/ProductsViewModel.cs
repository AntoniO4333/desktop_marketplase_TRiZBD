using System.Collections.ObjectModel;
using System.Windows.Input;
using static web_marketplase_TRiZBD.Models.Classes;

namespace web_marketplase_TRiZBD.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;

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
            Products = new ObservableCollection<Product>();
            AddProductCommand = new RelayCommand(ExecuteAddProduct);
            DeleteProductCommand = new RelayCommand(ExecuteDeleteProduct, CanExecuteModifyProduct);
            EditProductCommand = new RelayCommand(ExecuteEditProduct, CanExecuteModifyProduct);

            // Загрузите ваш список продуктов здесь, если есть начальные данные
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            // Это пример, реальные данные следует загружать из базы данных или другого источника
            Products.Add(new Product { ProductID = 1, Name = "Example Product 1", Price = 100.00m, Quantity = 10 });
            Products.Add(new Product { ProductID = 2, Name = "Example Product 2", Price = 150.00m, Quantity = 20 });
        }

        private void ExecuteAddProduct(object parameter)
        {
            var newProduct = new Product { Name = "New Product", Price = 0, Quantity = 0 };
            Products.Add(newProduct);
            SelectedProduct = newProduct;
        }

        private void ExecuteDeleteProduct(object parameter)
        {
            if (SelectedProduct != null && Products.Contains(SelectedProduct))
            {
                // Тут можно добавить логику проверки, можно ли удалять продукт
                Products.Remove(SelectedProduct);
            }
        }

        private void ExecuteEditProduct(object parameter)
        {
            // Перед редактированием можно выводить форму или диалог с деталями продукта для редактирования
            // Пока здесь просто пример без реализации
        }

        private bool CanExecuteModifyProduct(object parameter)
        {
            return SelectedProduct != null;
        }
    }
}