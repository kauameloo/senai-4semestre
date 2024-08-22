import React, { useState } from "react";
import { ContainerLB, ContainerMain } from "../Containers/StyledContainer";
import { Dates } from "../Date/Dates";
import { SearchBar } from "../SearchBar/SearchBar";
import { Button } from "../Buttons/Buttons";
import { List } from "../Cards/Cards";
import { ModalNewTask } from "../ModalNewTask/ModalNewTask";
import Modal from "react-modal";

Modal.setAppElement("#root");

const Main = () => {
  const [showModal, setShowModal] = useState(false);

  function openModal() {
    setShowModal(true);
  }
  return (
    <ContainerMain>
      <Dates />
      <SearchBar />
      <ContainerLB>
        <List />
        <Button text={"Nova tarefa"} onClick={openModal} />
      </ContainerLB>

      <ModalNewTask isOpen={showModal} />
    </ContainerMain>
  );
};

export default Main;
