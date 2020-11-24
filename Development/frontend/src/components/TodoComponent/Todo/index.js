import { Typography } from "@material-ui/core";
import React from "react";
import { Container, ListItem } from './styles';

function Todo({ todo, toggleComplete, removeTodo }) {
  function handleCheckboxClick() {
    toggleComplete(todo.id);
  }

  function handleRemoveClick() {
    removeTodo(todo.id);
  }

  return (
    <Container>
        <ListItem>
        <input type="checkbox" checked={todo.completed} onClick={handleCheckboxClick} />

        <h4
          variant="body1"
          style={{
            textDecoration: todo.completed ? "line-through" : null
          }}
        >
          {todo.task}
        </h4>

        <h3 onClick={handleRemoveClick}>X</h3>
        </ListItem>
    </Container>
    
  );
}

export default Todo;