import React, { useEffect, useState } from 'react';

import TodoForm from '../TodoComponent/TodoForm';
import TodoList from '../TodoComponent/TodoList';

import { Calendar2Check, X, PencilSquare, Trash } from 'react-bootstrap-icons';

import { ModalContent, Container, InputTitle, InputWrapper, InputColor, InputDescription, TodoArea, End } from './styles';

const LOCAL_STORAGE_KEY = "react-todo-list-todos";

const Modal = ({id = 'Modal', onClose = () => {}}) => {

    const handleOutsideClick = (e) => {
        if(e.target.id === id) onClose()
    }

    function changeColor() {
            let color = document.getElementById('colorInput').value;
    }

    const [todos, setTodos] = useState([]);

    useEffect(() => {
        const storageTodos = JSON.parse(localStorage.getItem(LOCAL_STORAGE_KEY));
        if (storageTodos) {
        setTodos(storageTodos);
        }
    }, []);

    useEffect(() => {
        localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(todos));
    }, [todos]);

    function addTodo(todo) {
        setTodos([todo, ...todos]);
    }

    function toggleComplete(id) {
        setTodos(
        todos.map(todo => {
            if (todo.id === id) {
            return {
                ...todo,
                completed: !todo.completed
            };
            }
            return todo;
        })
        );
    }

    function removeTodo(id) {
        setTodos(todos.filter(todo => todo.id !== id));
    }

    return(
        <ModalContent id={id} onClick={handleOutsideClick}>

                <Container>
                    <button onClick={onClose}>
                        <X width="30px" height="30px"/>
                    </button>

                    <h3>Gerencie sua tarefa.</h3>

                    <InputTitle>
                        <input type="text" placeholder="Tarefa"/>
                    </InputTitle>

                    <InputWrapper>
                        <input type="time" />
                        <input type="date" />
                    </InputWrapper>

                    <InputColor>
                        <h5>Selecione a cor de sua tarefa</h5>
                        <div>
                            <input type="color" id="colorInput"/>
                            <button id="colorButton"onClick={changeColor}>
                                Salvar cor
                            </button>
                        </div>
                    </InputColor>

                    <InputDescription>
                        <textarea placeholder="Descrição"/>
                    </InputDescription>

                    <TodoArea>
                        <h5>Qual seus palnos para essa tarefa?</h5>
                        <TodoForm addTodo={addTodo} />
                        <TodoList
                            todos={todos}
                            removeTodo={removeTodo}
                            toggleComplete={toggleComplete}
                        />
                    </TodoArea>

                    <End>
                        <button> <Trash width="30px" height="50px"/> </button>
                        <button> <PencilSquare width="30px" height="50px"/> </button>
                        <button> <Calendar2Check width="30px" height="30px"/> </button>
                    </End>

                </Container>

            </ModalContent>
    ) 
}

export default Modal;