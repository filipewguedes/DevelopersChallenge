NIBO Full-Stack Developers Challenge - Level 1
==============

Quer saber o por que vale a pena trabalhar no nibo? Acesse [nibodev.github.io](https://nibodev.github.io) e conheça a cultura e as tecnologias que utilizamos!

------------

Bem vindo à Summoners Rift. 

Você foi convocado a participar do mais empolgante desafio de sua vida: acabar com os intermináveis conflitos em Valoran. A nação humana de Demacia, o assombroso império de Noxus e os moradores de todas as cidades-estado aguardam ansiosamente por este momento.

Para isso ocorrerá um torneio onde o reino do vencedor terá o poder de controlar todos os outros em Valoran e precisamos que você desenvolva um sistema para gerenciar este torneio.

Regras
-------------------------
Os torneios tipicamente mata-mata são compostos por times e chaves, onde são gerados os vencedores de cada chave até chegar ao grande vencedor do torneio.
Seu objetivo é criar um sistema onde é possível cadastrar os times e gerenciar o torneio até a fase final, onde poderemos eleger o vencedor.

![Formato do torneio](torneio.jpeg)

- Você deverá desenvolver uma solução **WEB** em C# .NET utilizando os frameworks, tecnologias e conceitos que julgar melhor (mas não queremos nada em Webforms :D)
- Queremos como resultado uma solução simples, legível e de qualidade. 
- Código feito e comentado em **inglês** please.
- Não utilize soluções prontas. Nós as conhecemos.
- Seja criativo. Você decide quais funcionalidades irá incluir além dos requisitos.

Envio da solução
-------------------------

Ao final, você deverá criar um fork deste repositório, incluir o seu código fonte, incluir o seu currículo dentro da pasta "_about",  preencher o formulário "_about/Profile.md" e enviar para dev@nibo.com.br o link do seu fork.

Tenha capricho com seu código e com o resultado final. Essa é a sua chance de entrar para o melhor time, na startup que mais cresce no Brasil.

"Domine à si mesmo, e dominará seu inimigo" - Lee Sin

**NIBO - Desenvolvimento de alta performance para geeks inquietos**

Boa sorte :D



------------

Isto é uma API Rest
Seguem abaixo os endpoints

------------

*Get*
/Tournament
Retorna todas as partidas e seus resultados(Quando o torneio foi iniciado, veja abaixo como)

*Get*
/Tournament/Winner
Retorna o campeao do torneio

*Post*
/Tournament/Teams
> NomeTime

Adiciona um time ao torneio

*Post*
/Tournament/Start
Inicia o torneio e cria as partidas

*Post*
/Tournament
> {
"match" : 0,
"score1" : 2,
"score2" : 1
}

Insere o resultado de uma partida
match = Numero da partida(Segue-se a ordem das partidas retornadas pelo metodo Get)
score1 = resultado time 1
score2 = resultado do time 2

------------

Ps : A arquitetura ta longe do ideal, foi oque deu pra fazer em um dia pra atender os requisitos
