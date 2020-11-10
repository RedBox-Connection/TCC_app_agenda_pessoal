import React, { useState } from 'react';

import ListTodoListForm from '../List-TodoListForm';
import ListTodo from '../ToDoList';

import { Container, Content } from './styles';

export default function TodoList() {
    const [listTodos, setListTodos] = useState([]);

  const addListTodo = listTodo => {
    if (!listTodo.text || /^\s*$/.test(listTodo.text)) {
      return;
    }

    const newListTodos = [ListTodo, ...listTodos];

    setListTodos(newListTodos);
    console.log(...listTodos);
  };

  const updateTodo = (listTodoId, newValue) => {
    if (!newValue.text || /^\s*$/.test(newValue.text)) {
      return;
    }

    setListTodos(prev => prev.map(item => (item.id === listTodoId ? newValue : item)));
  };

  const removeTodo = id => {
    const removedArr = [...listTodos].filter(listTodo => listTodo.id !== id);

    setListTodos(removedArr);
  };

    return (
        <Container>
            <h5>Qual seus planos para hoje?</h5>
            <ListTodoListForm onSubmit={addListTodo}/>
            <Content>
              <ListTodo
                listTodos={listTodos}
                removeTodo={removeTodo}
                updateTodo={updateTodo}
              />

              <ListTodo
                listTodos={listTodos}
                removeTodo={removeTodo}
                updateTodo={updateTodo}
              />
            </Content>
        </Container>
    )
}
