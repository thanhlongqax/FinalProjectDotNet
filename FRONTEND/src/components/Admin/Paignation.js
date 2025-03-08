import React from "react";
import PropTypes from "prop-types";
import {
    Typography,
    Button,
    CardFooter,
    IconButton
} from "@material-tailwind/react";
Pagination.propTypes = {
  pagination: PropTypes.object.isRequired,
  onPageChange: PropTypes.func,
};
Pagination.defaultProps = {
  onPageChange: null,
};

function Pagination(props) {
  const { pagination, onPageChange } = props;
  const { page, limit, totalRows } = pagination;
  const totalPages = Math.ceil(totalRows / limit);
  function handlePageChange(newPage) {
    if (onPageChange) {
      onPageChange(newPage);
    }
  }
  return (
    <CardFooter className="flex items-center justify-between border-t border-blue-gray-50 p-4">
    <Typography variant="small" color="blue-gray" className="font-normal">
        Page 1 of 10
    </Typography>
    <div className="flex flex-row gap-2">
        <Button variant="outlined" size="sm"
            disabled={page <=1}
            onClick={() => handlePageChange(page -1)}
        >
            Trước
        </Button>
        <div className="flex items-center gap-2">
            <IconButton variant="outlined" size="sm"
                onClick={() => handlePageChange(1)}
            >
                1
            </IconButton>
            <IconButton variant="text" size="sm"
                onClick={() => handlePageChange(2)}
            >
                2
            </IconButton>
            <IconButton variant="text" size="sm"
                onClick={() => handlePageChange(3)}
            >
                3
            </IconButton>
            <IconButton variant="text" size="sm">
                ...
            </IconButton>
            <IconButton variant="text" size="sm"
                onClick={() => handlePageChange(8)}
            >
                8
            </IconButton>
            <IconButton variant="text" size="sm"
                onClick={() => handlePageChange(9)}
            >
                9
            </IconButton>
            <IconButton variant="text" size="sm"
                onClick={() => handlePageChange(10)}
            >
                10
            </IconButton>
        </div>
        <Button variant="outlined" size="sm"
            disabled={page >= totalPages}
            onClick={() => handlePageChange(page + 1)}
        >
            Sau
        </Button>
    </div>
    </CardFooter>
  )
}
export default Pagination;