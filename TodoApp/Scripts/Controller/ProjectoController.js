﻿app.controller("ProjectoController", function ($scope, ProjectoService) {
    $scope.divBook = false;
    TodosProjectos();
    //Lista dos projectos
    function TodosProjectos() {

        var getProjectoData = ProjectoService.getProjectos();
        getProjectoData.then(function (Projecto) {
            $scope.Projectos = Projecto.data;
        }, function () {
            alert('Erro ao carregar Projectos');
        });
    }

    $scope.editBook = function (book) {
        var getBookData = bookService.getBook(book.Id);
        getBookData.then(function (_book) {
            $scope.book = _book.data;
            $scope.bookId = book.Id;
            $scope.bookTitle = book.Title;
            $scope.bookAuthor = book.Author;
            $scope.bookPublisher = book.Publisher;
            $scope.bookIsbn = book.Isbn;
            $scope.Action = "Update";
            $scope.divBook = true;
        }, function () {
            alert('Error in getting book records');
        });
    }

    $scope.AddUpdateBook = function () {
        var Book = {
            Title: $scope.bookTitle,
            Author: $scope.bookAuthor,
            Publisher: $scope.bookPublisher,
            Isbn: $scope.bookIsbn
        };
        var getBookAction = $scope.Action;

        if (getBookAction == "Update") {
            Book.Id = $scope.bookId;
            var getBookData = bookService.updateBook(Book);
            getBookData.then(function (msg) {
                GetAllBooks();
                alert(msg.data);
                $scope.divBook = false;
            }, function () {
                alert('Error in updating book record');
            });
        } else {
            var getBookData = bookService.AddBook(Book);
            getBookData.then(function (msg) {
                GetAllBooks();
                alert(msg.data);
                $scope.divBook = false;
            }, function () {
                alert('Error in adding book record');
            });
        }
    }

    $scope.AddBookDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divBook = true;
    }

    $scope.deleteBook = function (book) {
        var getBookData = bookService.DeleteBook(book.Id);
        getBookData.then(function (msg) {
            alert(msg.data);
            GetAllBooks();
        }, function () {
            alert('Error in deleting book record');
        });
    }

    function ClearFields() {
        $scope.bookId = "";
        $scope.bookTitle = "";
        $scope.bookAuthor = "";
        $scope.bookPublisher = "";
        $scope.bookIsbn = "";
    }
    $scope.Cancel = function () {
        $scope.divBook = false;
    };
});