This is a project to demonstrate an issue with CarouselView in Windows.

The issue is described here:
https://github.com/dotnet/maui/issues/25991

Run the app, and it will populate a CarouselView with 2 people, Person 1 and Person 2.
It will show the first item in the collection, Person 1.
Click the Show Person 2 button and the CarouselView will scroll to the 2nd person as expected.
Click the Add Person button - a new person will be added to the underlying collection.
Notice how the CarouselView is now selecting Person 1! It should have stayed on Person 2!
