import {
    Card,
    CardBody,
    CardHeader,
    Typography,
} from "@material-tailwind/react";
import Chart from "react-apexcharts";
import { Square3Stack3DIcon } from "@heroicons/react/24/outline";


const chartConfig = {
    type: "line",
    height: 240,
    series: [
        {
            name: "Truy cập",
            data: [50, 40, 450, 300, 320, 500, 350],
        },
    ],
    options: {
        chart: {
            toolbar: {
                show: false,
            },
        },
        title: {
            show: "",
        },
        dataLabels: {
            enabled: false,
        },
        colors: ["#7F1515"],
        stroke: {
            lineCap: "round",
            curve: "smooth",
        },
        markers: {
            size: 0,
        },
        xaxis: {
            axisTicks: {
                show: false,
            },
            axisBorder: {
                show: false,
            },
            labels: {
                style: {
                    colors: "#616161",
                    fontSize: "12px",
                    fontFamily: "inherit",
                    fontWeight: 400,
                },
            },
            categories: [
                "1",
                "5",
                "10",
                "15",
                "20",
                "25",
                "30",
            ],
        },
        yaxis: {
            labels: {
                style: {
                    colors: "#616161",
                    fontSize: "12px",
                    fontFamily: "inherit",
                    fontWeight: 400,
                },
            },
        },
        grid: {
            show: true,
            borderColor: "#dddddd",
            strokeDashArray: 5,
            xaxis: {
                lines: {
                    show: true,
                },
            },
            padding: {
                top: 5,
                right: 20,
            },
        },
        fill: {
            opacity: 0.8,
        },
        tooltip: {
            theme: "dark",
        },
    },
};

const LineChart = () => {
    return (
        <Card className="w-full ml-2 m-2">
            <CardHeader
                floated={false}
                shadow={false}
                color="transparent"
                className="flex flex-col gap-4 rounded-none md:flex-row md:items-center"
            >
                <div className="w-max rounded-lg bg-gray-900 p-5 text-white">
                    <Square3Stack3DIcon className="h-6 w-6" />
                </div>
                <div>
                    <Typography variant="h6" color="blue-gray">
                        Truy cập
                    </Typography>
                    <Typography
                        variant="small"
                        color="gray"
                        className="max-w-sm font-normal"
                    >
                        Lượng truy cập website trong tháng vừa qua
                    </Typography>
                </div>
            </CardHeader>
            <CardBody className="px-2 pb-0">
                <Chart {...chartConfig} />
            </CardBody>
        </Card>
    );
}

export default LineChart;