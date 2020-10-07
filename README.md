## Pré-requisitos
- `dotnet --version`<br>
você deverá ter instalado a versão 3.1 do framework NET CORE
- o arquivo "DbHuiaTeste.bak" é um backup do banco SQLserver
- deve se configurar a connectionstring na pasta /HuiaTeste e alterar o "DefaultConnection".


## Iniciando e executando projeto...

- `git clone https://github.com/cloviswrodrigues/TesteHuia.git`
- `cd HuiaTeste`
- `dotnet run`


  
**Metodos GET**  
----
- Abaixo todos EndPoints disponiveis para buscars todos os registro do respectivo dados.
```
/Cadastro
/Lotes
/Pedidos
/PedidoItens
/Produtos
/Usuarios
```
- Abaixo todos EndPoints disponiveis para buscar um dado por ID.
```
/Cadastro/{id}
/Lotes/{id}
/Pedidos/{id}
/PedidoItens/{id}
/Produtos/{id}
/Usuarios/{id}
```

**Metodos POST**  
----
### Cadastrar um cliente ou vendedor
```
/Cadastros
```
* **Body request:**
```
{"cpf":"52952017085","nome":"Joao","dtnascimento":"1990-01-05T00:00:00"}
```

* **Success Response:**
    * **Code:** 201 <br /> 
* **Error Response:**
  * **Code:** 400 BAD REQUEST <br />  
  
  
### Cadastrar um Usuário
```
/Usuarios
```
* **Body request:**
```
{"login":"vendedor01","senha":"123","cadastroid":1}
```

* **Success Response:**
  * **Code:** 201 <br /> 
* **Error Response:**
  * **Code:** 400 BAD REQUEST <br />  
  
### Cadastrar um Produto
```
/Produtos
```
* **Body request:**
```
{"nome":"tenis adidas","cor":"preto","descricao":"tenis caminhada","valor":300.0,}
```

* **Success Response:**
  * **Code:** 201 <br /> 
* **Error Response:**
  * **Code:** 400 BAD REQUEST <br />    
  
### Cadastrar um Pedido
```
/Pedidos
```
* **Body request:**
```
{
    "cliente": {
            "id": 1
        },
    "vendedor": {
            "id": 3
        },
    "valortotal": 990,
    "dtcompra": "2020-10-01T00:00:00"   
}
```

* **Success Response:**
  * **Code:** 201 <br /> 
* **Error Response:**
  * **Code:** 400 BAD REQUEST <br />
  
### Cadastrar um Item no Pedido
```
/Produtos
```
* **Body request:**
```
{
    "pedidoid": 7,
    "produtoid": 4,
    "quantidade": 5
}
```

* **Success Response:**
  * **Code:** 201 <br /> 
* **Error Response:**
  * **Code:** 400 BAD REQUEST <br />    

**Metodos PUT**  
----




**Metodos DELETE**  
----
- Abaixo todos EndPoints disponiveis para deletar um dado por ID, utilizando metodo DELETE.
```
/Cadastro/{id}
/Lotes/{id}
/Pedidos/{id}
/PedidoItens/{id}
/Produtos/{id}
/Usuarios/{id}
```



