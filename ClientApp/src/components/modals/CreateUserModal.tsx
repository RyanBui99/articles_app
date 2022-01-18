import React from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import useMediaQuery from '@mui/material/useMediaQuery';
import { useTheme } from '@mui/material/styles';
import { AnyNsRecord } from 'dns';
import {
  Box,
  Typography,
  TextField,
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
} from '@material-ui/core';
import ICreateEditUser from '../../interfaces/ICreateEditUser';

/**
 * Modal for creating users, restricted to admin ONLY!!
 * @param props
 * @returns
 */
export default function CreateUserModal(props: any) {
  const theme = useTheme();
  const fullScreen = useMediaQuery(theme.breakpoints.down('md'));

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const data = new FormData(e.currentTarget);
    const createUserData: ICreateEditUser = {
      username: data.get('username'),
      password: data.get('password'),
      role: data.get('role'),
    };
  };

  return (
    <Dialog
      fullScreen={fullScreen}
      open={props.open}
      onClose={props.handleclose}
      aria-labelledby='responsive-dialog-title'
      fullWidth
    >
      <DialogTitle id='responsive-dialog-title'>Create new user</DialogTitle>
      <DialogContent
        dividers
        sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}
      >
        <Box component='form' onSubmit={handleSubmit}>
          <TextField
            margin='normal'
            required
            fullWidth
            id='username'
            label='username'
            name='username'
            autoComplete='username'
            autoFocus
            variant='outlined'
          />
          <TextField
            margin='normal'
            required
            fullWidth
            name='password'
            label='Password'
            type='password'
            id='password'
            autoComplete='current-password'
            variant='outlined'
          />

          <FormControl component='fieldset' margin='dense'>
            <FormLabel component='legend'>Roles</FormLabel>
            <RadioGroup row aria-label='roles' name='row-radio-buttons-group'>
              <FormControlLabel
                value='user'
                control={<Radio color='primary' />}
                label='User'
                name='role'
                id='role'
              />
              <FormControlLabel
                value='admin'
                control={<Radio color='primary' />}
                label='Admin'
                name='role'
                id='role'
              />
            </RadioGroup>
          </FormControl>
          <DialogActions>
            <Button autoFocus type='submit'>
              Create
            </Button>
          </DialogActions>
        </Box>
      </DialogContent>
    </Dialog>
  );
}
