# Articles website

## Tech stack
- Back: php, mysql
- Front: HTML, CSS, JS

## Task
- The goal is to develop a simple web application with PHP and JavaScript that allows the user to show and edit a collection of articles.
Functional requirements

The application composes of three main components: article list, article detail and article edit. It is save to assume that the application will be used by only one client at a time.

### Article list

The article list page is available at URL ./articles and implements the following functionality:

F01) Each page contains at most 10 articles.

F02) User can move to next/previous page by clicking Next/Previous buttons respectively.

F03) When the user is on the first/last page Previous/Next button is hidden.

F04) User can see the total number of pages on the screen.

F05) For each article in the list there is an article name.

F06) For each article in the list there is a link with the label Show. If a user clicks the link, they are navigated to the article view page - URL ./article/{id}.

F07) For each article in the list there is a link with the label Edit. If a user clicks the link, they are navigated to the article edit page - URL ./article-edit/{id}.

F08) For each article in the list there is a link with the label Delete. The delete operation must be handled using AJAX with HTTP DELETE request.

F09) There is a button with the label Create article.

F10) If a user clicks Create article button a dialog is shown. The dialog contains a text input field with the label Name, which can be used to specify the name of a new article. The input field is required to be non-empty and the length is limited to 32 characters. The dialog contains buttons Create and Cancel.

F11) If a user clicks on the Cancel button, the dialog is closed.

F12) The Create button is enabled only if the text input for the article name is not empty.

F13) If a user clicks the Create button, a new article is created. The article is created with given name and empty body. Next, the user is redirected to the article edit for the new article.

### Article detail

Article detail page is available at URL ./article/{id}, where {id} is an article identifier. The page implements the following functionality:

F14) User can view the article detail page by navigating to URL ./article-edit/{id}, where {id} is a valid article identifier.

F17) If a user press Edit button, then the user is redirected to the article edit page with URL ./article-edit/{id}.

F18) If a user press Back to articles button, then the user is redirected back to the first page of the article list.

### Article edit

Article edit page is available at URL ./article-edit/{id}, where {id} is an article identifier. The page implements the following functionality:

F19) User can view the article edit page by navigating to URL ./article-edit/{id}, where {id} is a valid article identifier.

F20) If an article with given {id} does not exist, then the 
server returns an empty document with status code 404.

F21) If an article exists, then edit form, button Save and button Back to articles are shown to the user.

F22) If a user press Back to articles button, the user is redirected back to the first page of the article list.

F23) The edit form contains text input for article name with label Name and a textarea for article content with label Content. The size of an article content is limited to 1024 characters. The size of an article name is limited to 32 characters.

F25) Save button

## What it looked like:

<img src="src/Screenshot 2023-01-02 at 16.19.33.png" height="400">
<img src="src/Screenshot 2023-01-02 at 16.19.23.png" height="400">
<img src="src/Screenshot%202023-01-02%20at%2015.29.17.png" height="400">