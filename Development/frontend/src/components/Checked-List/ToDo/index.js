import React, { useState } from 'react';

import TodoForm from '../ToDoForms';

import { Container, TodoText, Icons, Check } from './styles';

import { PencilSquare, Trash } from 'react-bootstrap-icons';

const Todo = ({ todos, completeTodo, removeTodo, updateTodo }) => {

    const [edit, setEdit] = useState({
        id: null,
        value: ''
    });

    const submitUpdate = value => {
        updateTodo(edit.id, value);
        setEdit({
            id: null,
            value: ''
        });
    };

    if (edit.id) {
        return <TodoForm edit={edit} onSubmit={submitUpdate} />;
    }

    return todos.map((todo, index) => (
        <Container className={todo.isComplete ? 'todo-row complete' : 'todo-row'}
             key={index}
        >
            <Check>

                <input type="checkbox"/>

                <TodoText key={todo.id} onClick={() => completeTodo(todo.id)}>
                    {todo.text}
                </TodoText>

            </Check>
            

            <Icons>
                <Trash onClick={() => removeTodo(todo.id)} height="30px" width="30px" className="Icon"/>
                <PencilSquare onClick={() => setEdit({ id: todo.id, value: todo.text })} height="30px" width="30px" className="Icon"/>
            </Icons>
        </Container>
  ));
};

export default Todo;