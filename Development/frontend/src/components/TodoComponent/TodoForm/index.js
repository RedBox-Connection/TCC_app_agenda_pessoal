import React, { useState } from "react";
import uuid from "uuid";
import {FormContainer} from './styles'

function TodoForm({ addTodo }) {
  const [todo, setTodo] = useState({
    id: "",
    task: "",
    completed: false
  });

  function handleTaskInputChange(e) {
    setTodo({ ...todo, task: e.target.value });
  }

  function handleSubmit(e) {
    e.preventDefault();
    if (todo.task.trim()) {
      addTodo({ ...todo, id: uuid.v4() });
      setTodo({ ...todo, task: "" });
    }
  }

  return (
    <FormContainer>
        <form className="todo-form" onSubmit={handleSubmit}>
          <input 
            label="Task"
            type="text"
            name="task"
            value={todo.task}
            onChange={handleTaskInputChange}
          />
          <button type="submit">Submit</button>
        </form>
    </FormContainer>
    
  );
}

export default TodoForm;