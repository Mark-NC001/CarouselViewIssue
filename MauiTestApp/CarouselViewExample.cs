using System.Collections.ObjectModel;

namespace MauiTestApp;

public class CarouselViewExample : ContentPage
{

	public class Person
	{
		public string Name { get; set; }
	}

	private ObservableCollection<Person> _collection = new ObservableCollection<Person>() { new Person() { Name = "Person 1" }, new Person() { Name = "Person 2" } };

	private CarouselView MyCarouselView { get; set; }

	public CarouselViewExample()
	{

		StackLayout mainStackLayout = new StackLayout();
		mainStackLayout.Margin = new Thickness(5);

		Label labelInstructions = new Label()
		{
			Text = "Instructions:\nThe CarouselView contains Person 1 and Person 2. It will initially show the first page, Person 1.\n" +
			"Click the 'Scroll to Person 2' button, and the CarouselView will correctly show Person 2.\n" +
			"Click 'Add Person', which will add a new Person record to the collection.\n" +
			"Notice now the CarouselView has jumped back to Person 1!"
		};
		mainStackLayout.Add(labelInstructions);

		MyCarouselView = new CarouselView()
		{
			ItemsSource = _collection,
			Loop = false
		};

		MyCarouselView.ItemTemplate = new DataTemplate(() =>
		{
			StackLayout stackLayout = new StackLayout();
			Label nameLabel = new Label();
			nameLabel.SetBinding(Label.TextProperty, "Name");
			nameLabel.FontSize = 25;
			nameLabel.TextColor = Colors.Red;
			stackLayout.Children.Add(nameLabel);
			return stackLayout;
		});

		mainStackLayout.Add(MyCarouselView);

		Button scrollToPerson2Button = new Button()
		{
			Text = "Scroll to Person 2"
		};
		scrollToPerson2Button.Clicked += ScrollToPerson2Button_Clicked;
		mainStackLayout.Add(scrollToPerson2Button);

		Button addPersonButton = new Button()
		{
			Text = "Add Person",
		};
		addPersonButton.Clicked += AddButton_Clicked;
		mainStackLayout.Add(addPersonButton);

		Content = mainStackLayout;

	}

	private void ScrollToPerson2Button_Clicked(object? sender, EventArgs e)
	{
		MyCarouselView.ScrollTo(1);
	}

	private void AddButton_Clicked(object? sender, EventArgs e)
	{
		_collection.Add(new Person()
		{
			Name = "Person " + (_collection.Count + 1),
		});
	}
}