import React, { useState } from 'react';
import { PencilSquare, Trash } from 'react-bootstrap-icons';

import { ContainerTodoForm, TodoFormContent, TodoFormContentEdit, FormCrud } from './styles';

export default function TodoForm(props) {

    const [input, setInput] = useState(props.edit ? props.edit.value : '');

    const handleChange = e => {
        setInput(e.target.value);
      };
    
      const handleSubmit = e => {
        e.preventDefault();
    
        props.onSubmit({
          id: Math.floor(Math.random() * 10000),
          text: input
        });
        setInput('');
      };

    return (
        <ContainerTodoForm>
            {props.edit ? (
                <TodoFormContentEdit>
                    <input
                        placeholder='Alterar Item'
                        value={input}
                        onChange={handleChange}
                        name='text'
                        id='todo-input-edit'
                    />
                    <button onClick={handleSubmit} id='todo-button-edit'>
                        Alterar
                    </button>
                </TodoFormContentEdit>
            ) : (
                <TodoFormContent>
                    <input
                        placeholder='Adicionar sub tarefa'
                        value={input}
                        onChange={handleChange}
                        name='text'
                        id='todo-input'
                        maxLength="30"
                    />
                    <FormCrud>
                        <button onClick={handleSubmit} id='todo-button'>
                            Add tarefa
                        </button>
                        <Trash height="30px" width="30px"/>
                        <PencilSquare height="30px" width="30px"/>
                    </FormCrud>
                    
                </TodoFormContent>
            )}
        </ContainerTodoForm>
    )
}


