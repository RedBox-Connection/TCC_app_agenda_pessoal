import React, { useState } from 'react';

import TodoForm from '../ToDoForms';

import { RiCloseCircleLine } from 'react-icons/ri';
import { TiEdit } from 'react-icons/ti';

import { Container, TodoText, Icons } from './styles';

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
            <TodoText key={todo.id} onClick={() => completeTodo(todo.id)}>
                {todo.text}
            </TodoText>

            <Icons>
                <RiCloseCircleLine
                    onClick={() => removeTodo(todo.id)}
                    className='delete-icon'
                />
                <TiEdit
                    onClick={() => setEdit({ id: todo.id, value: todo.text })}
                    className='edit-icon'
                />
            </Icons>
        </Container>
  ));
};

export default Todo;