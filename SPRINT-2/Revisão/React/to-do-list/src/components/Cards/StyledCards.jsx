import styled from "styled-components";

export const CardContainer = styled.div`
  width: 100%;
  height: 61.73px;
  background-color: #fcfcfc;
  border-radius: 7.72px;
  border: 0.77px solid #3c424a;

  background-color: ${(props) => (props.selected ? "#7D3C98" : "#FCFCFC")};
  border: 1px solid ${(props) => (props.selected ? "#7D3C98" : "#D8D8D8")};
  color: ${(props) => (props.selected ? "#FCFCFC" : "#1E123B")};

  display: flex;
  align-items: center;
  flex-shrink: 0;
`;

export const CardContent = styled.p`
  font-size: 15.43px;
  font-weight: 600;
  color: #25282c;
  margin: 0;
`;
