window.onload = function () {
    listarCama();
}
function listarCama() {
    pintar({
       
        url: "Cama/listarCama",
        id: "divtabla",
        cabeceras: ["Id Cama", "Nombre", "Descripcion"],
            propiedades: ["idcama", "nombre", "descripcion"],
        Editar:  true,
            Eliminar: true
    }, {
        busqueda: true,
        url: "Cama/filtrarCama",
        nombreparametro: "nombre",
        type: "text",
        button: false,
        id: "txtnombrecama"

    }, {
        type: "fieldset",
        legend: "Datos de la Cama",
        formulario: [
            [
                {
                    class: "mb-3 col-md-4",
                   
                    label: "Id Cama",
                    name: "id"
                    
                },
                {
                    class: "mb-3 col-md-5",
                   
                    label: "Nombre cama",
                    name: "nombre"
                   
                }

            ],
            [
                {
                    class: "mb-3 col-md-4",
                    type: "textarea",
                    label: "Descripcion Cama",
                    name: "descripcion",
                    rows: "4",
                    cols: "30"
                    
                }
            ]
        ]

    })
}


