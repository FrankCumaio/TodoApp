app.service("ProjectoService", function ($http) {

    //get All Books
    this.getProjectos = function () {
        return $http.get("ListaProjecto");
    };

    // get Book by bookId
    this.getBook = function (bookId) {
        var response = $http({
            method: "post",
            url: "GetBookById",
            params: {
                id: JSON.stringify(bookId)
            }
        });
        return response;
    }

    // Update Book 
    this.updateBook = function (book) {
        var response = $http({
            method: "post",
            url: "UpdateBook",
            data: JSON.stringify(book),
            dataType: "json"
        });
        return response;
    }

    // Add Book
    this.AddBook = function (book) {
        var response = $http({
            method: "post",
            url: "AddBook",
            data: JSON.stringify(book),
            dataType: "json"
        });
        return response;
    }

    //Delete Book
    this.DeleteBook = function (bookId) {
        var response = $http({
            method: "post",
            url: "DeleteBook",
            params: {
                bookId: JSON.stringify(bookId)
            }
        });
        return response;
    }
});