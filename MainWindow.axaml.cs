using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Books.Models;

namespace Books;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadBooks();
        MainContent.Content = new AddBookPage();
    }

    public void LoadBooks()
    {
        BooksList.ItemsSource = null;
        using (Context context = new Context())
        {
            List<Book> books = context.Books.OrderBy(x => x.Title).ToList();
            Search.ItemsSource = books;
            BooksList.ItemsSource = books;
        }
    }

    private void BooksList_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        Book selectedItem = (Book)BooksList.SelectedItem!;
        MainContent.Content = new BookInfo(selectedItem.Title, selectedItem.Author, selectedItem.Annotation);
    }

    private void Search_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        Book selectedItem = (Book)Search.SelectedItem!;
        MainContent.Content = new BookInfo(selectedItem.Title, selectedItem.Author, selectedItem.Annotation);
    }
}