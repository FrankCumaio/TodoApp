app.service("ProjectoService", function ($http) {

    //get All Projectos
    this.getProjectos = function () {
        return $http.get("ListaProjecto");
    };

    // get Book by bookId
    this.getProjecto = function (projectoid) {
        alert("y");
        var response = $http({
            method: "post",
            url: "GetProjectoById",
            params: {
                id: JSON.stringify(projectoid)
            }
        });
        return response;
    }

    // Update Projecto
    this.updateProjecto = function (projecto) {
        var response = $http({
            method: "post",
            url: "updateProjecto",
            data: JSON.stringify(projecto),
            dataType: "json"
        });
        return response;
    }

    // Adicionar projecto
    this.AddProjecto = function (projecto) {
        var response = $http({
            method: "post",
            url: "gravar",
            data: JSON.stringify(projecto),
            dataType: "json"
        });
        return response;
    }

    //apagar projecto
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