$(function (){
    var produtos = []
    $.ajax({
        type: 'GET',
        url: 'https://localhost:8000/api/Produto',
        success: function(response) {
            produtos = response
            buildProdutosTable(produtos)
            console.log(produtos)
        }
    });

    function buildProdutosTable(data){
        var table = document.getElementById('produtos-output')

        data.forEach(produto =>
        {
            var row = `<tr>
                        <td>${produto.Id}</td>
                        <td>${produto.Descricao}</td>
                        <td>${produto.ValorUnitario}</td>
            </tr>`;                   
            table.innerHTML += row                   
        });
    }



    // GET PRODUTO BY DESCRICAO
    $('#confirm-button2').click(function () {
        var descricao = $('#descricao-input').val();
        if (descricao){
            $.ajax({
                type: 'GET',
                url: `https://localhost:8000/api/Produto/descricao/${descricao}`,
                success: function (response) {
                    if(response){
                        $('#produtos-container').hide();
                        $('#produto-container').show();
                        $('#single-produto-output').empty();
                        buildSingleProdutoTable(response);
                    } else {
                        alert('Produto não encontrado.');
                    }
                },
                error: function () {
                    alert('Erro ao buscar o produto.');
                }
            });
        }
        else {
            alert('Por favor, insira um produto.');
        }
    });

    function buildSingleProdutoTable(produto){
        var table =  document.getElementById('single-produto-output')

        var row = `<tr>
               <td>${produto.Id}</td>
               <td>${produto.Descricao}</td>
               <td>${produto.ValorUnitario}</td>                       
            </tr>`;                        
    
            table.innerHTML += row
    }

    $('#show-produtos-link').click(function () {
        $('#descricao-input').val(''); // Limpa o campo de entrada
        $('#single-produto-output').empty(); // Limpa a tabela de cliente específico
        $('#produto-container').hide(); // Esconde a tabela de cliente específico
        $('#produtos-container').show(); 
    });
});