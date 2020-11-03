# ASP.NET Core Pratice - Library Due Date Tracker
This practice is a part of the TECHCareers Software Developer Program.

## Introduction
This practice is meant to challenge your mastery of ASP.NET Web Application (Model - View - Controller) and how well you are able to use MVC to create a CRUD application. Your goal in this practice is to create a tool that will help you keep track of all the books that are checked out of a library. This is a cumulative activity. You will be adding onto this code for consequent practice.

## Requirements
* “Book” Class:
  * All of the following properties are read only, except for “DueDate” and “ReturnedDate”.
  * Properties:
    * int “ID”
    * string “Title”
    * DateTime “PublicationDate”
    * DateTime “CheckedOutDate”
    * DateTime “DueDate”
    * This will update with each extension (via the ExtendDueDateForBookByID() method).
    * DateTime? “ReturnedDate”
    * string “Author”
  * Constructor:
    * Accepts the “ID”, “Title”, “Author”, “PublicationDate” and “CheckedOutDate” as parameters.
    * “DueDate” will be set to 14 days after “CheckedOutDate”.
    * “ReturnedDate” will be set to null.
* “BookController” Class which inherits from “Controller”:
  * A public static “Books” property which is a list of “Book” objects.
  * Action/View “Index”.
    * Modify this default action to redirect to the “List” action.
  * Action/View “Create”
    * Will display the form to create an object. 
    * Call the “CreateBook()” method with the supplied query string parameters.
    * Handle any exceptions thrown by “CreateBook()”;
    * Success Message: "You have successfully checked out {title} until {DueDate}."
    * Error Message: “Unable to check out book: {Exception.Message}.”
  * Action/View “List”
    * Render a list of all books as links in the format “{Title} by {Author}” that will load the “Details” Action/View for that book when clicked.
  * Action/View “Details”
    * If no query string parameter “id” was supplied, render “No book selected.”
    * If an “id” query string parameter was supplied, use “GetBookByID()” and render:
      * "You checked out {Title} on {CheckedOutDate}, and the due date is {DueDate}."
      * A button that will call “ExtendDueDateForBookByID()”.
      * A button that will call “ReturnBookByID()”.
      * A button that will call “DeleteBookByID()”.
  * Method “CreateBook()”.
    * Accepts the same parameters as the “Book” constructor.
    * Creates and adds a “Book” to the “Books” list.
    * Ensures the provided “ID” is unique in the list.
    * Throw an exception if the “ID” already exists.
  * Method “GetBookByID()”.
    * Returns the “Book” object with the given “ID” from the “Books” list.
  * Method “ExtendDueDateForBookByID()”.
    * Extensions are 7 days from today’s date.
  * Method “ReturnBookByID()”.
    * Sets the “ReturnedDate” of the “Book” object with the given “ID” to the current date.
  * Method “DeleteBookByID()”.
    * Removes the “Book” object with the given “ID” from the “Books” list.
* Add links to your “List” and “Create” views to the page navigation.
* Add a brief description of your project to the homepage of the application.

## Challenges
Make it look nice with CSS.
Add an “Edit” Action/View that will allow you to manually update the due date of a book.
Make the Book-related navigation links into a Bootstrap dropdown.
Display the “List” View as an HTML table rather than an HTML list.
Have an unexpected feature.

### Support
Please contact me at Kenji1@ualberta.ca for trouble-shooting.
