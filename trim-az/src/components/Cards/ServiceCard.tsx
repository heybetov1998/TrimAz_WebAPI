import CardFrame from "../UI/CardFrame";
import Column from "../UI/grid/Column";
import Row from "../UI/grid/Row";

type PropsType = {
    name: string;
    price: number;
    time: string;
};

const ServiceCard = (props: PropsType) => (
    <CardFrame className="service_card">
        <Row className="align-items-center">
            <Column lg={8} xl={8}>
                <h4 className="name">{props.name}</h4>
                <span className="time">{props.time}</span>
            </Column>
            <Column lg={4} xl={4}>
                <p className="price">{props.price} AZN</p>
            </Column>
        </Row>
    </CardFrame>
);

export default ServiceCard;
