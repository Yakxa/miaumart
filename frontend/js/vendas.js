$(function (){
    var vendas = []
    $.ajax({
        type: 'GET',
        url: 'https://localhost:8000/api/Venda',
        success: function(response) {
            vendas = response
            buildVendasTable(vendas)
            console.log(vendas)
        }
    });

    function buildVendasTable(data){
        var table = document.getElementById('vendas-output')

        for(var i = 0; i < data.length; i++)
            {
                var row = `<tr>
                    <td>${data[i].NomeCliente}</td>
                    <td>${data[i].DescricaoProduto}</td>
                    <td>${data[i].QuantidadeVenda}</td>
                    <td>${data[i].ValorUnitarioVenda}</td>
                    <td>${data[i].ValorTotalVenda}</td>
                    <td>${new Date(data[i].DataVenda).toLocaleDateString()}</td>
                </tr>`;
                table.innerHTML += row    
            };                       
        };

    // GET VENDA BY NOME CLIENTE
    $('#confirm-button3').click(function () {
        var nome = $('#venda-nome-input').val();
        if (nome){
            $.ajax({
                type: 'GET',
                url: `https://localhost:8000/api/Venda/by-cliente/${nome}`,
                success: function (response) {
                    console.log(response)
                    if(response){
                        $('#venda-clientes-container').hide();
                        $('#venda-cliente-container').show();
                        $('#vendas-output').empty();
                        buildVendasByClienteTable(response);
                    } else {
                        alert('Venda não encontrada.');
                    }
                },
                error: function () {
                    alert('Erro ao buscar venda.');
                }
            });
        }
        else {
            alert('Por favor, insira uma venda.');
        }
    });

    function buildVendasByClienteTable(data) {
        var table = document.getElementById('#venda-nomes-output');
        console.log($('#venda-nomes-output')); 
        data.forEach(venda => {
            var row = `
                <tr>
                    <td>${venda.nomeCliente}</td>
                    <td>${venda.descricaoProduto}</td>
                    <td>${venda.quantidadeVenda}</td>
                    <td>${venda.valorUnitarioVenda}</td>
                    <td>${venda.valorTotalVenda}</td>
                    <td>${new Date(venda.dataVenda).toLocaleDateString()}</td>
                </tr>`;
                table.innerHTML += row
        });
    }

    $('#show-vendas-link').click(function () {
        $('#venda-nome-input').val('');
        $('#vendas-nomes-output').empty();
        $('#venda-clientes-container').show(); 
        $('#venda-nomes-container').hide(); 
    });
});