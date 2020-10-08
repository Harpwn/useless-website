import React, { useState, useEffect } from 'react';
import AsyncCreatableSelect from 'react-select/async-creatable';
import * as routing from '../../../common/routing';
import PropTypes from 'prop-types';


const TagEntrySelect = (props) => {

    const [loading, setLoading] = useState(false);
    const asyncRef = React.createRef();

    useEffect(() => {
        setLoading(false);
    }, [props.section])


    async function loadOptions(inputValue) {
        if (!inputValue || inputValue.length < 3) {
            return [];
        }
        const response = await fetch(routing.GetTagSearchUrl(inputValue));
        const json = await response.json();
        return json;
    };


    const handleChange = (selectedOption) => {
        if (selectedOption) {
            setLoading(true);
            props.addTagEntry(props.section, selectedOption.value);
        }
    }

    const isValidSelectOptions = (inputValue) => {
        return inputValue && inputValue.length > 2
    }

    const customStyles = {
        option: (provided, state) => ({
          ...provided,
          color: state.isSelected ? 'white' : 'black',
        }),
      }
      

    return (
        <div>
            <AsyncCreatableSelect
                cacheOptions
                styles={customStyles}
                loadOptions={loadOptions}
                defaultOptions={[]}
                onChange={handleChange}
                isLoading={loading}
                isDisabled={loading}
                isClearable={true}
                ref={asyncRef}
                isValidNewOption={isValidSelectOptions}
            />
        </div>
    )
}

TagEntrySelect.propTypes = {
    section: PropTypes.object.isRequired,
    addTagEntry: PropTypes.func.isRequired,
}

export default TagEntrySelect
