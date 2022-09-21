import React from "react";

type Props = {
    children?: React.ReactNode;
};

const Container: React.FC<Props> = (props) => (
    <div className="container">{props.children}</div>
);

export default Container;
