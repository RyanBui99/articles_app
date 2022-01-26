import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import CloseIcon from '@mui/icons-material/Close';
import useMediaQuery from '@mui/material/useMediaQuery';
import { useTheme } from '@mui/material/styles';
import {
  Box,
  TextField,
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  IconButton,
  DialogTitle,
} from '@material-ui/core';
import ICreateEditUser from '../../interfaces/ICreateEditUser';
import SnackbarComponent from '../SnackbarComponent';
import { useDispatch } from 'react-redux';
import { addUsers } from '../../store/actionCreators/userCreator';
import { AlertColor } from '@mui/material';

/**
 * Modal for creating users, restricted to admin ONLY!!
 * @param props
 * @returns
 */
export default function CreateUserModal(props: any) {
  const theme = useTheme();
  const dispatch = useDispatch();
  const fullScreen = useMediaQuery(theme.breakpoints.down('md'));
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState('');
  const [severity, setSeverity] = useState<AlertColor>();

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
      const data = new FormData(e.currentTarget);
      const createUserData: ICreateEditUser = {
        email: data.get('username')!.toString(),
        password: data.get('password')!.toString(),
        role: data.get('role')!.toString(),
      };

      await dispatch(addUsers(createUserData));
      setSeverity('success');
      setMessage('User created successfully');
      props.handleclose();
    } catch (error: any) {
      setSeverity('error');
      if (error.response == undefined)
        setMessage('Something went wront. Maybe you forgot something');
        
      setMessage(error.response.data.message);
    }
  };

  return (
    <>
      <SnackbarComponent
        open={open}
        handleClose={handleClose}
        message={message}
        severity={severity}
      />
      <Dialog
        fullScreen={fullScreen}
        open={props.open}
        onClose={props.handleclose}
        aria-labelledby='responsive-dialog-title'
        fullWidth
      >
        <DialogActions
          sx={{ display: 'flex', justifyContent: 'space-between' }}
        >
          <DialogTitle id='responsive-dialog-title'>
            Create new user
          </DialogTitle>
          <IconButton
            edge='start'
            color='inherit'
            onClick={props.handleclose}
            aria-label='close'
          >
            <CloseIcon />
          </IconButton>
        </DialogActions>
        <DialogContent
          dividers
          sx={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
          }}
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
              <Button onClick={handleClick} autoFocus type='submit'>
                Create
              </Button>
            </DialogActions>
          </Box>
        </DialogContent>
      </Dialog>
    </>
  );
}
