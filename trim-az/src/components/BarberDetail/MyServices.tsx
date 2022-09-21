import ServiceCard from "../Cards/ServiceCard";
import Column from "../UI/grid/Column";
import Row from "../UI/grid/Row";
import SectionPartName from "../UI/section/SectionPartName";

const services = [
    { id: 1, name: "Saç qırxmaq", price: 24, time: "00:30" },
    { id: 2, name: "Saqqal qırxma", price: 24, time: "00:15" },
    { id: 3, name: "Saç rənglənməsi", price: 24, time: "00:45" },
];

const MyServices = () => (
    <div className="my_services">
        <SectionPartName text="My Services" />
        <div className="service_holder">
            <Row>
                {services.map((service) => (
                    <Column key={service.id} md={6} lg={6} xl={6}>
                        <ServiceCard
                            name={service.name}
                            price={service.price}
                            time={service.time}
                        />
                    </Column>
                ))}
            </Row>
        </div>
    </div>
);

export default MyServices;
