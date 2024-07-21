$(function (){
    // GET ALL CLIENTES
    var clientes = []
    $.ajax({
        type: 'GET',
        url: 'https://localhost:8000/api/Cliente',
        success: function(response) {
            clientes = response
            buildClientesTable(clientes)
            console.log(clientes)
        }
    });

    function buildClientesTable(data){
        var table = document.getElementById('clientes-output')

        data.forEach(cliente =>
        {
            var row = `<tr>
                        <td>${cliente.Id}</td>
                        <td>${cliente.Nome}</td>
                        <td>${cliente.Cidade}</td>
                        
                </td>
            </tr>`;                        
                       
            table.innerHTML += row
                    
        });
    }
    
    // GET CLIENTE BY NOME
    $('#confirm-button').click(function () {
        var nome = $('#nome-input').val();
        if (nome){
            $.ajax({
                type: 'GET',
                url: `https://localhost:8000/api/Cliente/nome/${nome}`,
                success: function (response) {
                    if(response){
                        $('#clientes-container').hide();
                        $('#cliente-container').show();
                        $('#single-cliente-output').empty();
                        buildSingleClienteTable(response);
                    } else {
                        alert('Cliente não encontrado.');
                    }
                },
                error: function () {
                    alert('Erro ao buscar o cliente.');
                }
            });
        }
        else {
            alert('Por favor, insira um nome.');
        }
    });

    function buildSingleClienteTable(cliente){
        var table =  document.getElementById('single-cliente-output')

        var row = `<tr>
               <td>${cliente.Id}</td>
               <td>${cliente.Nome}</td>
               <td>${cliente.Cidade}</td>                       
            </tr>`;                        
    
            table.innerHTML += row
    }

    $('#show-clientes-link').click(function () {
        $('#nome-input').val(''); // Limpa o campo de entrada
        $('#single-cliente-output').empty(); // Limpa a tabela de cliente específico
        $('#cliente-container').hide(); // Esconde a tabela de cliente específico
        $('#clientes-container').show(); 
    });
    
});