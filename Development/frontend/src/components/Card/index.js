//Import React, Npm
import React, { useState, useRef } from 'react';
import { useDrag, useDrop } from 'react-dnd';

//Import Modal
import Modal from '../Modal';

//Import Styles
import { CardContent, Content } from './styles';

export default function Card(props) {

    const nomeCartao = props.card.nomeCartao;
    const idCartao = props.card.idCartao;
    const hora = props.card.hora;
    const idQuadro = props.idQuadro;

    //Modal Function
    const [isModalVisible,setIsModalVisible] = useState(false);

    //Drag n' Drop Functions
    // const ref = useRef();

    // const [{isDragging}, dargRef] = useDrag({
    //     item: { type: 'CARD'},
    //     collect: monitor =>({
    //         isDragging: monitor.isDragging(),
    //     }),
    // });

    // const [, dropRef] = useDrop({
    //     accept:'CARD',
    //     hover(item, monitor) {

    //     }
    // })

    // dargRef(dropRef(ref));

    // isDragging={isDragging}

    // ref={ref}

    return (
        <CardContent>

            <button id="Card-Button" onClick={() =>setIsModalVisible(true)} >
                <Content>
                    <p>{nomeCartao}</p>
                    <h3>{hora}</h3>
                </Content>
            </button>

            {isModalVisible ? <Modal card={props.card} idQuadro={idQuadro} onClose={() => setIsModalVisible(false)}/> : null}

        </CardContent>
    );
}
