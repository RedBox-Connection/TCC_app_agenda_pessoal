//Import React, Npm
import React, { useState, useRef } from 'react';
import { useDrag, useDrop } from 'react-dnd';

//Import Modal
import Modal from '../Modal';

//Import Styles
import { CardContent, Color, Content } from './styles';

//Import Api

export default function Card(props) {

    //Services Api
    

    //Modal Function
    const [isModalVisible,setIsModalVisible] = useState(false);

    //Drag n' Drop Functions
    const ref = useRef();

    const [{isDragging}, dargRef] = useDrag({
        item: { type: 'CARD'},
        collect: monitor =>({
            isDragging: monitor.isDragging(),
        }),
    });

    const [, dropRef] = useDrop({
        accept:'CARD',
        hover(item, monitor) {
            
        }
    })

    dargRef(dropRef(ref));

    return (
        <CardContent ref={ref} isDragging={isDragging}>

            <button id="Card-Button" onClick={() =>setIsModalVisible(true)}>
                <Color />
                <Content>
                    <h3>Titulo</h3>
                    <h1>18:00</h1>
                </Content>
            </button>

            {isModalVisible ? <Modal onClose={() => setIsModalVisible(false)}/> : null}

        </CardContent>
    );
}
