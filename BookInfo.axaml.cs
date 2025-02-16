using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Books;

public partial class BookInfo : UserControl
{
    
    public BookInfo(string title, string author, string annotation)
    {
        
        InitializeComponent();

        Title.Text = title;
        Author.Text = author;
        Annotation.Text = annotation;
    }
}