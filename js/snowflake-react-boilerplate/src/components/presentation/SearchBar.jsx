import React from 'react'
import muiInjectSheet from 'utils/muiInjectSheet'

import Paper from 'material-ui/Paper'
import FormControl from 'material-ui/Form/FormControl'
import Input from 'material-ui/Input/Input'
import SearchIcon from 'material-ui-icons/Search'

import { grey, red } from 'material-ui/styles/colors'

import styleable from 'utils/styleable'

const styles = {
  barContainer: {
    width: '100%',
    display: 'grid',
    gridTemplateColumns: '48px auto 10px',
    alignItems: 'center',
    opacity: 1,
    '&:hover, &:focus': {
      opacity: 1
    },
    fontFamily: 'Roboto, sans-serif'
  },
  searchIcon: {
    justifySelf: 'center'
  },
  textFieldUnderline: {
    '&:after': {
      backgroundColor: red[400]
    }
  }
}

const SearchBar = ({classes, tagline, onChange}) => (
  <Paper className={classes.barContainer}>
    <SearchIcon color={grey[400]} className={classes.searchIcon}/>
    <FormControl className={classes.input}>
          <Input
            placeholder={"Search " + (tagline || "")}
            className={classes.textFieldUnderline}
            onChange={onChange}
          />
        </FormControl>
  </Paper>
)

export default muiInjectSheet(styles)(SearchBar);