/* Proyecto Final
*
*
*
*/


function LlenaSelectJson(ObjetoJSON) {		
    var elValor;
    var elHTML;
    for (i=0; i < ObjetoJSON.length; i++)
    {	
        elValor = ObjetoJSON[i].callingCodes;
        elHTML = ObjetoJSON[i].name;
        $('#miCombo').append( $('<option></option>').val(elValor).html(elHTML) );	
    }		
}//Fin LlenaSelectJson ================================================ 

function formatNumber(n) {
    // format number 1000000 to 1,234,567
    return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
  }
  
  
  function formatCurrency(input, blur) {
    // appends $ to value, validates decimal side
    // and puts cursor back in right position.
    
    // get input value
    var input_val = input.val();
    
    // don't validate empty input
    if (input_val === "") { return; }
    
    // original length
    var original_len = input_val.length;
  
    // initial caret position 
    var caret_pos = input.prop("selectionStart");
      
    // check for decimal
    if (input_val.indexOf(".") >= 0) {
  
      // get position of first decimal
      // this prevents multiple decimals from
      // being entered
      var decimal_pos = input_val.indexOf(".");
  
      // split number by decimal point
      var left_side = input_val.substring(0, decimal_pos);
      var right_side = input_val.substring(decimal_pos);
  
      // add commas to left side of number
      left_side = formatNumber(left_side);
  
      // validate right side
      right_side = formatNumber(right_side);
      
      // On blur make sure 2 numbers after decimal
      if (blur === "blur") {
        right_side += "00";
      }
      
      // Limit decimal to only 2 digits
      right_side = right_side.substring(0, 2);
  
      // join number by .
      input_val = "$" + left_side + "." + right_side;
  
    } else {
      // no decimal entered
      // add commas to number
      // remove all non-digits
      input_val = formatNumber(input_val);
      input_val = "$" + input_val;
      
      // final formatting
      if (blur === "blur") {
        input_val += ".00";
      }
    }
    
    // send updated string to input
    input.val(input_val);
  
    // put caret back in the right position
    var updated_len = input_val.length;
    caret_pos = updated_len - original_len + caret_pos;
    input[0].setSelectionRange(caret_pos, caret_pos);
  }

// Inicialisar Javascrip Para examen. 
$( document ).ready(function() {
    
	console.log( "ready!" );
    
    //alert ( "Cargo" );
	
	
	//$('#loginform').validate();
    
    // Validacion del login Principal
    $("#loginform").validate({
        
        rules: {
            
            username: {
                required: true,
                minlength: 5,
                email: true
            },
            password: {
                required: true,
                minlength: 5,
                maxlength: 16
            }           
            
        },
        
        messages: {
            username: {
                required:  "Digite el Usuario",
                minlength: "El usuario requiere al menos 5 caracteres.",
                email:     "Digite un email valido."
            },
            password: {
                required:  "Digite la Clave",
                minlength: "La clave requiere al menos 6 caracteres."
            },
            
            
            email_nada: "Please enter a valid email address",
            agree_nada: "Please accept our policy",
            topic_nada: "Please select at least 2 topics"
        }
    });
  
    
    // Validacion del Cliente
    //
    //____________________________________________________________________________________________________________
    //____________________________________________________________________________________________________________
    
    $("#form-clientes").validate({
        
       
        rules: {
            usuario: {
                required: true,
                minlength: 5
            },
            clave: {
                required: true,
                minlength: 5
            },
            clave_confirmacion: {
                required: true,
                minlength: 6,
                maxlength: 16,
                equalTo: "#clave"
            },
            nombre:  {
                required: true,
                minlength: 5
            },
            cedula: {
                required: true,
                minlength: 6,
                maxlength: 16,
                digits: true
            },
            nacimiento: {
                required: true,
                dateISO: true
            },
            email:  {
                required: true,
                email: true
            },
            pais:  {
                required: true
            },
            area:  {
                required: true,
                minlength: 2
            },
            telefono:  {
                required: true,
                minlength: 6
            },
            provincia:  {
                required: true,
                minlength: 3
            },
            canton:  {
                required: true,
                minlength: 3
            },
            distrito:  {
                required: true,
                minlength: 3
            },
            direccion:  {
                required: true,
                minlength: 10
            }
            
        },
        
        messages: {
            usuario: {
                required:  "Digite el Usurio",
                minlength: "El usuario requiere al menos 5 caracteres." 
                /*email:     "Digite un email valido."*/
            },
            clave: {
                required:  "Digite la Clave",
                minlength: "El usuario requiere al menos 5 caracteres."
            },
            clave_confirmacion: {
                required:  "Digite la Confirmación de la Clave",
                minlength: "La clave requiere al menos 6 caracteres."
            },
            nombre: {
                required:  "Digite el nombre del cliente",
                minlength: "El nombre require de minimo 2 caracteres."
            },
            cedula: {
                required:  "Digite la cédula del cliente",
                minlength: "Mínimo 2 caracteres."
            },
            nacimiento: {
                required:  "Digite la fecha de nacimiento",
                minlength: "Mínimo 2 caracteres.",
                dateISO:   "Digite una fecha válida"
            },
            email:     "Digite una dirección de correo válida",
            telefono: {
                required:  "Digite un teléfono",
                minlength: "Mínimo 6 caracteres."
            },
            area: {
                required:  "Digite código de area",
                minlength: "Mínimo 2 caracteres."
            },
            provincia: {
                required:  "Digite un provincia",
                minlength: "Mínimo 3 caracteres."
            },
            canton: {
                required:  "Digite un cantón",
                minlength: "Mínimo 3 caracteres."
            },
            distrito: {
                required:  "Digite un distrito",
                minlength: "Mínimo 3 caracteres."
            },
            direccion: {
                required:  "Digite una dirección",
                minlength: "Mínimo 10 caracteres."
            }
            
            
        }
    });   
   
    // Validacion de Productos
    //
    //____________________________________________________________________________________________________________
    //____________________________________________________________________________________________________________
    
    $("#form-productos").validate({
        
       
        rules: {
            codigo: {
                required: true,
                minlength: 1,
                digits: true,
                min:1
                
            },
            descripcion: {
                required: true,
                minlength: 5
            },
            precio:  {
                required: true,
                minlength: 1,
                number: true,
                min:1
            },
            minimo: {
                required: true,
                minlength: 1,
                number: true,
                min:1
            },
            ingreso: {
                required: true,
                dateISO: true
            }
            
        },
        
        messages: {
            codigo: {
                required:  "Digite el Código",
                minlength: "El código requiere al menos 1 caracteres." ,
                digits:    "Solo digitar números enteros",
                min:       "El Código mayor a igual a 1"
            },
            descripcion: {
                required:  "Digite la Descripción",
                minlength: "Mínimo 5 caracteres."
            },
            precio: {
                required:  "Digite el precio del producto",
                minlength: "Mínimo 1 caracteres",
                number:    "Digite un número",
                min:       "El Código mayor a igual a 1"
            },
            minimo: {
                required:  "Digite el stuck mínimo",
                minlength: "Mínimo 1 caracteres",
                number:    "Digite un número",
                min:       "El mínimo mayor a igual a 1"
            },
            ingreso: {
                required:  "Digite la fecha de ingreso",
                minlength: "Mínimo 2 caracteres.",
                dateISO:   "Digite una fecha válida"
            }
            
            
        }
    });     
   
    // Validacion de Facturacion
    //
    //____________________________________________________________________________________________________________
    //____________________________________________________________________________________________________________
    
    $("#form-facturacion").validate({
        
       
        rules: {
            
            
            cliente: {
                required: true,
                minlength: 1,
                
            },
            descripcion1: {
                required: true,
                minlength: 1,
                
            },
            descripcion2: {
                required: true,
                minlength: 1,
                
            },
            descripcion3: {
                required: true,
                minlength: 1,
            },
            precio1: {
                required: true,
                minlength: 1,
                number:true,
                min:1
            },
            precio2: {
                required: true,
                minlength: 1,
                number:true,
                min:1                
            },
            precio3: {
                required: true,
                minlength: 1,
                number:true,
                min:1                
            },
            cantidad1: {
                required: true,
                minlength: 1,
                number:true,
                min:1,
                digits: true                
            },
            cantidad2: {
                required: true,
                minlength: 1,
                number:true,
                min:1,
                digits: true                
            },
            cantidad3   : {
                required: true,
                minlength: 1,
                number:true,
                min:1,
                digits: true                
            },
            total   : {
                required: true,
                minlength: 1,
                number:true,
                min:1                
            }
            
            
        },
        
        messages: {

            descripcion1: {
                required:  "Digite la Descripción",
                minlength: "Mínimo 5 caracteres."
            },
            descripcion2: {
                required:  "Digite la Descripción",
                minlength: "Mínimo 5 caracteres."
            },
            descripcion3: {
                required:  "Digite la Descripción",
                minlength: "Mínimo 5 caracteres."
            },
            cantidad1: {
                required:  "Digite la Cantidad",
                minlength: "Digite la Cantidad",
                min:       "Digite la Cantidad"
            },
            cantidad2: {
                required:  "Digite la Cantidad",
                minlength: "Digite la Cantidad.",
                min:       "Digite la Cantidad"
            },
            cantidad3: {
                required:  "Digite la Cantidad",
                minlength: "Digite la Cantidad",
                min:       "Digite la Cantidad"
            },
            precio1: {
                required:  "Digite el Precio",
                minlength: "Digite el Precio",
                min:       "Digite la Precio"
            },
            precio2: {
                required:  "Digite el Precio",
                minlength: "Digite el Precio.",
                min:       "Digite la Precio"
            },
            precio3: {
                required:  "Digite el Precio",
                minlength: "Digite el Precio",
                min:       "Digite la Precio"
            },
            
        }
    });       
   
   

    try {
        $.ajax({
            //url: 'paises.json'
            url: 'https://restcountries.eu/rest/v1/all'
        })
        .done(function (data) {
            LlenaSelectJson(data);
        });
    } catch (err) {
        alert(err);
    }

    
    $('#miCombo').change(function() {
      $("#area").val( "+" + $(this).val() ) ;
    });
    
    function linea_factura(linea) {

       if (linea==1) {
            var data = $("#producto1").val();
            var arr  = data.split('|');
            $("#descripcion1").val(arr[1]);
            $("#precio1").val(arr[2]);
       }

       if (linea==2) {
            var data = $("#producto2").val();
            var arr  = data.split('|');
            $("#descripcion2").val(arr[1]);
            $("#precio2").val(arr[2]);
       }

       if (linea==3) {
            var data = $("#producto3").val();
            var arr  = data.split('|');
            $("#descripcion3").val(arr[1]);
            $("#precio3").val(arr[2]);
       }        
    }    

    function update_total() {
        
        var subtotal1 = 0;
        var subtotal2 = 0;
        var subtotal3 = 0;

        var iva1 = 0;
        var iva2 = 0;
        var iva3 = 0;        


        if (  $.isNumeric( $("#precio1").val()) & $.isNumeric( $("#cantidad1").val())  ) {
            var subtotal1 = $("#precio1").val() * $("#cantidad1").val();
            var iva1      = subtotal1*0.13;
        }
        
        if (  $.isNumeric( $("#precio2").val()) & $.isNumeric( $("#cantidad1").val())  ) {
            var subtotal2 = $("#precio2").val() * $("#cantidad2").val();
            var iva2      = subtotal2*0.13;
        }
        
        if (  $.isNumeric( $("#precio3").val()) & $.isNumeric( $("#cantidad3").val())  ) {
            var subtotal3 = $("#precio3").val() * $("#cantidad3").val();
            var iva3      = subtotal3*0.13;
        }        
        
        $("#iva").val(iva1+iva2+iva3);
        $("#total").val(subtotal1+subtotal2+subtotal3);
    
    }  
  
  
    //Procedimientos para Facturacion
    $('#producto1').change(function() {
        linea_factura(1);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#producto1').focusout(function() {
        linea_factura(1);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#precio1').change(function() {
        linea_factura(1);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#precio1').focusout(function() {
        linea_factura(1);
        update_total();
    });    
    
    $('#cantidad1').change(function() {
        linea_factura(1);
        update_total();
    }); 
    $('#cantidad1').focusout(function() {
        linea_factura(1);
        update_total();
    });
    
    //#############################################################
    //Procedimientos para Facturacion
    $('#producto2').change(function() {
        linea_factura(2);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#producto2').focusout(function() {
        linea_factura(2);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#precio2').change(function() {
        linea_factura(2);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#precio2').focusout(function() {
        linea_factura(2);
        update_total();
    });    
    
    $('#cantidad2').change(function() {
        linea_factura(2);
        update_total();
    }); 
    $('#cantidad2').focusout(function() {
        linea_factura(2);
        update_total();
    });    
  
    //#############################################################
    //Procedimientos para Facturacion
    $('#producto3').change(function() {
        linea_factura(3);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#producto3').focusout(function() {
        linea_factura(3);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#precio3').change(function() {
        linea_factura(3);
        update_total();
    });
    
    //Procedimientos para Facturacion
    $('#precio3').focusout(function() {
        linea_factura(3);
        update_total();
    });    
    
    $('#cantidad3').change(function() {
        linea_factura(3);
        update_total();
    }); 
    $('#cantidad3').focusout(function() {
        linea_factura(3);
        update_total();
    });


    //Para campos money
    $("input[data-type='currency']").on({
        keyup: function() {
          formatCurrency($(this));
        },
        blur: function() { 
          formatCurrency($(this), "blur");
        }
    });
	
	
});

$(document).ready(function() {
    
    $("#loader-wrapper").hide();

});


