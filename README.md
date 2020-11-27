# Organizer

O organizer é um sistema de organização baseado no metódo kanban, ele foi criado pensando em como se organizar em projetos de muitas tarefas

**[Entrar no organizer](http://54.152.237.245:3000/)**

Feito por : **RedBox Connection**

### Colaboradores:
   * [Kevin Alves N° 24](https://github.com/KevinAlvss)
   * [Gustavo Apolonio N° 15](https://github.com/Gustavo-Apolonio)
   * [Diego Souza N° 08](https://github.com/diego0425)
   * [Arthur Pereira N° 04](https://github.com/uArthurSPereira)


# Links 

[Trello](https://trello.com/b/R2EDLbiV/redbox-tcc)


# Casos de Uso
  
  ## Cartão Tarefa
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/UseCase/imagens%20use%20case/cart%C3%A3o%20tarefa.PNG?raw=true)
  
  O usuário tem total controle sobre o cartão de tarefa, ele poderá marcar como concluido, deletar, alterar nome e adicionar mais to-dos, mas se até a data de entrega ele não marcar como concluido o cartão será transferido para parte de atrasados
  
  ## Cartão Time
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/UseCase/imagens%20use%20case/cart%C3%A3o%20time.PNG?raw=true)
  
  O cartão de time possui as mesmas funcionalidades que o cartão individual, porém só os admins do time podem deleta-los e altera-los
  
  Obs: Um admin pode promover um usuário a admin na tela de configuração de time
  
  ## Conta
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/UseCase/imagens%20use%20case/conta.PNG?raw=true)
  
  O usuário tem total controle sobre a própria conta, ele pode alterar o nome, nome de usuário, senha; o osuário também pode deletar sua conta
  
  ## Login
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/UseCase/imagens%20use%20case/esqueci%20a%20senha.PNG?raw=true)
  
  O usuário pode entrar em sua conta com o email e senha, se por um acaso o usuário esquecer a senha ele receberá um email com um código de verificação e poderá redefinir sua senha 
  
  ## Time

  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/UseCase/imagens%20use%20case/time.PNG?raw=true)
  
  O admin pode convidar pessoas para seu time através do link disponiblizado nas configurações do time, pode deletar o time, alterar o nome do time, retirar cargos de admins e promover usuários comuns a admin do time

# Mer
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Database_MER/Mer.png?raw=true)
  
  ## Scrip do Bando de Dados
  ```drop database tccdb;
create database tccdb;

use tccdb;

create table tb_login(
	id_login int auto_increment primary key not null,
    ds_email varchar(100) not null,
    ds_senha varchar(100) not null,
    dt_ult_login datetime not null
);

create table tb_esqueci_senha(
	id_esqueci_senha int auto_increment primary key not null,
    ds_email varchar(100),
    nr_codigo long not null,
    tm_inclusao datetime not null,
    tm_expiracao datetime not null,
    id_login int not null,
    foreign key (id_login) references tb_login (id_login) on delete cascade
);

create table tb_usuario(
	id_usuario int auto_increment primary key not null,
    nm_perfil varchar(100) not null,
    nm_usuario varchar(100) not null,
    ds_foto varchar(200) not null,
    bt_receber_email bool not null,
    id_login int not null,
    foreign key (id_login) references tb_login (id_login) on delete cascade
);

create table tb_quadro(
	id_quadro int auto_increment primary key not null,
    nm_quadro varchar(100) not null,
    id_usuario int not null,
    foreign key (id_usuario) references tb_usuario (id_usuario) on delete cascade
);

create table tb_time(
	id_time int auto_increment primary key not null,
    nm_time varchar(100) not null,
    ds_time varchar(500),
    ds_link_convite varchar(100),
    id_quadro int not null,
    foreign key (id_quadro) references tb_quadro (id_quadro) on delete cascade
);

create table tb_time_integrante(
	id_integrante int auto_increment primary key not null,
    id_time int not null,
    id_usuario int not null,
    ds_permissao varchar(100) not null,
    foreign key (id_usuario) references tb_usuario (id_usuario) on delete cascade,
    foreign key (id_time) references tb_time (id_time) on delete cascade
);

create table tb_cartao(
	id_cartao int auto_increment primary key not null,
    nm_cartao varchar(100) not null,
    ds_cartao varchar(500),
    dt_inclusao datetime not null,
    dt_termino datetime not null,
    ds_cor varchar(100) not null,
    ds_status varchar(100) not null,
    id_quadro int not null,
    foreign key (id_quadro) references tb_quadro (id_quadro) on delete cascade
);

create table tb_cartao_comentario(
	id_comentario int auto_increment primary key not null,
    ds_comentario varchar(300) not null,
    dt_inclusao datetime not null,
    id_cartao int not null,
    id_usuario int not null,
    foreign key (id_cartao) references tb_cartao (id_cartao) on delete cascade,
    foreign key (id_usuario) references tb_usuario (id_usuario) on delete cascade
);

create table tb_checklist(
	id_checklist int auto_increment primary key not null,
    nm_checklist varchar(100) not null,
    id_cartao int not null,
    foreign key (id_cartao) references tb_cartao (id_cartao) on delete cascade
);

create table tb_checklist_item(
	id_item int auto_increment primary key not null,
    nm_item varchar(100) not null,
    bt_feito bool not null,
    id_checklist int not null,
    foreign key (id_checklist) references tb_checklist (id_checklist) on delete cascade
);
```
  
# Protótipos

  ## Tela inicial
  ![Tela inicial](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/Tela%20inicial.PNG?raw=true)
  
  ## Tela de cadastro
  
  ![cadastro](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/tela%20de%20cadastro.PNG?raw=true)
  
  ## Tela de login
  
  ![login](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/tela%20de%20login.PNG?raw=true)
  
  ## Processo de esqueci a senha
  
  ![1](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/esqueci%20a%20senha%201.PNG?raw=true)
  ![2](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/esqueci%20a%20senha%202.PNG?raw=true)
  ![3](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/definir%20nova%20senha.PNG?raw=true)
  
  ## Escolher um quadro
  
  ![quadros](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/escolha%20de%20quadros.PNG?raw=true)
  
  ## Agenda
  
  ![agenda](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/agenda.PNG?raw=true)
  
  ## Pop ups
  
  ![pop ups](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/pop%20ups.PNG?raw=true)
  
  ## Tarefas feitas
  
  ![feitos](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/tarefas%20feitas.PNG?raw=true)
  
  ## Tarefas atrasadas
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/tarefas%20atrasadas.PNG?raw=true)
  
  ## Tela de configuração de usuário
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/configura%C3%A7%C3%A3o%20de%20usuario.PNG?raw=true)
  
  ## Criar um time
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/criar%20um%20time.PNG?raw=true)
  
  ## Agenda (Time)
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/agenda%20de%20time.PNG?raw=true)
  
  ## Configuração de time
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/configura%C3%A7%C3%A3o%20de%20tme.PNG?raw=true)

  ## Tela de convite para um time
  
  ![](https://github.com/RedBox-Connection/TCC_app_agenda_pessoal/blob/master/Software_Engineer/Prototyping/imagens%20prototipos/tela%20de%20convite.PNG?raw=true)
  

