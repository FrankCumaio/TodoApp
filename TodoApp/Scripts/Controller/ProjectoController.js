app.controller("ProjectoController", function ($scope, ProjectoService) {
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
    //Edicao de projectos
    $scope.editarProjecto = function (projecto) {
        var getProjectoData = ProjectoService.getProjecto(projecto.id);
        getProjectoData.then(function (_projecto) {
            $scope.projecto = _projecto.data;
            $scope.projectoId = projecto.id;
            $scope.nome = projecto.nome;
            $scope.dataInicio = projecto.dataInicio;
            $scope.dataFim = projecto.dataFim;
            $scope.membro = projecto.membro;
            $scope.Action = "Update";
            $scope.divBook = true;
        }, function () {
            alert('Error in getting book records');
        });
    }
    //Adiciao e actualizacao de novo projecto
    $scope.AddUpdateProjecto = function () {
        if ($scope.Action == null) {
            $scope.Action = "Add";
            alert($scope.Action);
        }
        var projecto = {
            Nome: $scope.nome,
            DataInicio: $scope.dataInicio,
            DataFim: $scope.dataFim,
            Estado:$scope.estado ="Activo",
            membro: $scope.membro
        };
        var getProjectoAction = $scope.Action;

        if (getProjectoAction == "Update") {
            projecto.id = $scope.projectoId;
            var getProjectoData = ProjectoService.updateProjecto(projecto);
            getProjectoData.then(function (msg) {
                TodosProjectos();
                alert(msg.data);
            }, function () {
                alert('Erro ao actulizar dados');
            });
        } else {
            var getProjectoData = ProjectoService.AddProjecto(projecto);
            getProjectoData.then(function (msg) {
                TodosProjectos();
                alert(msg.data);
            }, function () {
                alert('Erro ao Adicionar novo Projecto');
            });
        }
    }

    $scope.AddBookDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divBook = true;
    }

    $scope.deleteBook = function (book) {
        var getProjectoData = bookService.DeleteBook(book.Id);
        getProjectoData.then(function (msg) {
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