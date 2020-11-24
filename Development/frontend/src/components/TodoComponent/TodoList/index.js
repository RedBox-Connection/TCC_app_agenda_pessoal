import React from "react";
import Todo from "../Todo";
import {ListContainer} from './styles';

function TodoList({ todos, removeTodo, toggleComplete }) {
  return (
    <ListContainer>
      <div>
      {todos.map(todo => (
        <Todo
          key={todo.id}
          todo={todo}
          removeTodo={removeTodo}
          toggleComplete={toggleComplete}
        />
      ))}
      </div>
    </ListContainer>
  );
}

export default TodoList;