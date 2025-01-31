window.onload = function()
{
    listarTipoHabiatacion();
}
function listarTipoHabiatacion() {
    pintar({
        url: "TipoHabitacion/lista", id: "divtabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
  
        
    })
}

function Buscar() {
    var nombretipohabitacion = get("txtnombretipohabitacion")
    
    pintar({
        url: "TipoHabitacion/filtrarTipoHabitacionPorNombre/?nombrehabitacion=" + nombretipohabitacion,
        id: "divtabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
         editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}

function Limpiar() {
  
    LimpiarDatos("frmTipoHabitacion")
    Correcto("Se limpio con Exito!");
}

function GuardarDatos() {

    var frmTipoHabitacion = document.getElementById("frmTipoHabitacion");
    var frm = new FormData(frmTipoHabitacion);
    fetchPostText("TipoHabitacion/guardarDatos", frm, function (res) {
            if (res == "1") {
                listarTipoHabiatacion();
                Limpiar();
                Correcto("Se guardo con Exito!");
                

            }
    })

}
function Editar(id) {
  
    recuperarGenerico("TipoHabitacion/recuperarTipoHabitacion/?id=" + id, "frmTipoHabitacion");
    Correcto("Los datos se editaran!");
    
}

function Eliminar(id) {
    Confirmacion("Desea Eliminar los datos", "Confirmar eliminacion", function (res) {
        fetchGetText("TipoHabitacion/eliminarTipoHabitacion/?id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Se elimino con exito!");
                listarTipoHabiatacion();
            }
        })
    })
}

