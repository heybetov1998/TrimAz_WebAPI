import React from "react";

type Props = {
    children?: React.ReactNode;
};

const HeaderNavigation: React.FC<Props> = (props) => {
    return <nav className="h-100">{props.children}</nav>;
};

export default HeaderNavigation;
